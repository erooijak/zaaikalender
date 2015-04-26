﻿using System;
using System.Threading;
using System.Linq;
using System.Web.Mvc;

using Zk.Services;
using Zk.Helpers;
using Zk.Models;

namespace Zk.Controllers
{
    [AllowAnonymous]
    public class CalendarController : Controller
    {        
        readonly CalendarService calendarService;
        readonly FarmingActionService farmingActionService;
        readonly CropProvider cropProvider;

        public CalendarController(
            CalendarService calendarService,
            FarmingActionService farmingActionService,
            CropProvider cropProvider)
        {
            this.calendarService = calendarService;
            this.farmingActionService = farmingActionService;
            this.cropProvider = cropProvider;
        }

        // 
        // GET: /Month/{month}
        // Returns the farming actions of the month.
        public ActionResult Month(Month month)
        {
            var monthCalendarViewModel = calendarService.GetMonthCalendar(month);

            return PartialView(Url.View("_MonthCalendar", "Home"), monthCalendarViewModel);
        }

        //
        // GET: /Calendar/Year
        public ActionResult Year()
        {
            var calendarViewModel = calendarService.GetYearCalendar();

            return View(calendarViewModel);
        }

        /// <summary>
        ///     POST: /UpdateMonth/{formCollection} 
        ///     Update the relevant farming actions with the new data from the month.
        /// </summary>
        /// <returns>JSONResult indicating success or failure.</returns>
        /// <param name="fc">FormCollection with id of farming action and crop count.</param>
        [HttpPost]
        public JsonResult UpdateMonth(FormCollection fc)
        {
            // Convert the crop count and farming action id's string arrays to integer arrays.
            var farmingActionIds = fc["action.Id"].Split(',').Select(int.Parse).ToList();
            var cropCounts = fc["action.CropCount"].Split(',').Select(int.Parse).ToList();

            try 
            {
                // Update crop counts in database
                farmingActionService.UpdateCropCounts(farmingActionIds, cropCounts);
            } 
            catch (Exception ex) 
            {
                // TODO: Implement logging
                return Json(new { success = false });
            }

            return Json(new { success = true });
        }

        //
        // POST /Calendar/RemoveFarmingAction
        [HttpPost]
        public JsonResult RemoveFarmingAction(int id)
        {
            try 
            {
                // Remove this and related farming action from database
                farmingActionService.RemoveAction(id);
            } 
            catch (Exception ex) 
            {
                // TODO: Implement logging
                return Json(new { success = false });
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult AddFarmingAction(int cropId, Month month, ActionType actionType, int cropCount)
        {

            var crop = cropProvider.GetCrop(cropId);
            var calendar = calendarService.Get();

            var farmingAction = new FarmingAction 
            {
                Action = actionType,
                Calendar = calendar,
                Crop = crop,
                CropCount = cropCount,
                Month = month
            };

            try
            {
                farmingActionService.AddAction(farmingAction);
                return Json(new { success = true });
            }
            catch (Exception ex) 
            { 
                // TODO: Implement logging
                return Json(new { success = false });
            }

        }
            
    }
}