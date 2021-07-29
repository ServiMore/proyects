using System;
using Entities;
using System.Collections.Generic;
using DAL;

namespace BLL {
    public class EmployeeBL {

        private EmployeeDA da = new EmployeeDA();

        public List<Employee> GetAll() {
            return da.GetAll();
        }

        public Employee GetOne(string code) {
            return da.GetOne(code);
        }

        public List<Employee> GetChildren(Employee boss) {
            return da.GetChildren(boss);
        }

        public void Create(Employee employee) {
            if (employee.Salario <= 0) {
                throw new Exception("El salario no puede ser negativo.");
            }
            if (string.IsNullOrWhiteSpace(employee.Codigo)) {
                throw new Exception("El codigo no puede estar vacio.");
            }
            if (employee.Jefe != null && employee.Codigo == employee.Jefe.Codigo) {
                throw new Exception("El empleado no puede ser su propio jefe.");
            }


            da.Create(employee);
        }

    }
}
