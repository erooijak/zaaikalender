﻿using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

using Oogstplanner.Controllers;
using Oogstplanner.ViewModels;
using Oogstplanner.Services;

namespace Oogstplanner.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Controllers_Home_c_MonthOrdering()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var passedViewModel = (SowingAndHarvestingViewModel)((ViewResult)controller.SowingAndHarvesting()).Model;

            // Assert
            var expectedMonthOrdering = new Stack<string>(new[] 
            {   
                "augustus", "mei",   "februari", "november",  
                "juli",     "april", "januari",  "oktober",      
                "juni",     "maart", "december", "september"       
            });

            Assert.AreEqual(expectedMonthOrdering, passedViewModel.MonthsOrdered,
                "The months should be ordered in the above way to have proper display.");
        }

    }
}