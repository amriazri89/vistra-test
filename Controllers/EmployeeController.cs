using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VistraTest.Models;

namespace VistraTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly string _connectionString;

        public EmployeeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET: /Employee/Index
        public IActionResult Index()
        {
            var employees = new List<EmployeeBiodata>();

            string query = @"
                SELECT employee_no, employee_name, birth_date
                FROM   employee_biodata
                WHERE  (   employee_name LIKE 'A%'
                        OR employee_name LIKE 'G%'
                        OR employee_name LIKE 'V%')
                  AND  MONTH(birth_date) BETWEEN 1 AND 3
                ORDER BY employee_name";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new EmployeeBiodata
                        {
                            EmployeeNo   = reader["employee_no"].ToString(),
                            EmployeeName = reader["employee_name"].ToString(),
                            BirthDate    = Convert.ToDateTime(reader["birth_date"])
                        });
                    }
                }
            }

            return View(employees);
        }
    }
}
