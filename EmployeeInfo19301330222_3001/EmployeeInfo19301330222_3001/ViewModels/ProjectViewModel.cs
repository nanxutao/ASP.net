using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeInfo19301330222_3001.Models;

namespace EmployeeInfo19301330222_3001.ViewModels
{
    public class ProjectViewModel
    {
        public  ProjectViewModel()
        {
            Projects = new List<Project>();
            EmployeesInProject = new List<Employee>();
        }
        public int SelectedProjectID{get;set;}
        public List <Project> Projects{get;set;}
        public List <Employee> EmployeesInProject{get;set;}
    }
}