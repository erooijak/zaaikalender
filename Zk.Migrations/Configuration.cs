﻿using System;
using System.Data.Entity.Migrations;
using Zk.Models;
using System.Data.Entity.Migrations.Sql;

namespace Zk.SqlTool
{
	public class Configuration : DbMigrationsConfiguration<ZkContext>
	{
		public Configuration ()
		{

			AutomaticMigrationsEnabled = false;
			SetSqlGenerator("Npgsql", new PostgreSqlMigrationSqlGenerator());
		}

	}
}

