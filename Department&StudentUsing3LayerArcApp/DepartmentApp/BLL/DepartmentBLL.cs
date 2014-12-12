using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentApp.DLL.DAO;
using DepartmentApp.DLL.GETWAY;

namespace DepartmentApp.BLL
{
    class DepartmentBLL
    {
        public DepartmentBLL()
        {
            aDepartmentGetway= new DepartmentGetway();
        }

        private DepartmentGetway aDepartmentGetway;
        public string Save(Department aDepartment)
        {
            if (aDepartment.Name == string.Empty || aDepartment.Code == string.Empty)
            {
                return "please fill up all field";
            }
            else
            {
                if ((HasThisNameValid(aDepartment.Name)) || (HasThisCodeValid(aDepartment.Code)))
                {
                    string msg = "";
                    if (HasThisNameValid(aDepartment.Name))
                    {
                        msg += "Name already in system\n";
                    }
                    if (HasThisCodeValid(aDepartment.Code))
                    {
                        msg += "Code already in system\n";
                    }
                    return msg;
                }
                else
                {
                    return aDepartmentGetway.Save(aDepartment);
                   
                }
            }
        }

        private bool HasThisNameValid(string name)
        {
            return aDepartmentGetway.HasThisNameValid(name);
        }
        private bool HasThisCodeValid(string code)
        {
            return aDepartmentGetway.HasThisCodeValid(code);
        }

        public List<Department> GetAllDepartment()
        {
            return aDepartmentGetway.GetAllDepartment();
        }
    }
}
