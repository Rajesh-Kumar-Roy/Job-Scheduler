using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TimeSchudlerApp.DataConn;
using TimeSchudlerApp.Models;

namespace TimeSchudlerApp.Repository
{
    public interface ISalaryRepository
    {
        List<Salary> GetAllSalary();
        void InsertListOfData(List<Salary> dataList);
    }
    public class SalaryRepository: ISalaryRepository
    {
        
        
        private  ISalaryRepository _repository;

        private DbContext db;

        private HEllo Context
        {
            get { return (HEllo) db; }
        }

        public SalaryRepository(DbContext db)
        {
            this.db = (HEllo) db;
        }


        public List<Salary> GetAllSalary()
        {
            return Context.Salaries.ToList();
        }

        public void InsertListOfData(List<Salary> dataList)
        {
            List<SchdularDemo> d = new List<SchdularDemo>();
            foreach (var demo in dataList)
            {
                var v = new SchdularDemo();
                v.Name = demo.Name;
                v.Salary = demo.Month_Salary;
                d.Add(v);
            }

            Context.SchdularDemos.AddRange(d);
            Context.SaveChanges();
        }
    }
}
