using ORM_Dapper;
using System;
using System.Collections.Generic;
namespace IntroSQL
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

        void InsertDepartment(string newDepartmentName);//Stubbed out method
    }
}