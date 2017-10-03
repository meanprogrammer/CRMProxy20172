using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmployeeService : IEmployeeService
    {

        OrgContext context = null;

        public EmployeeService()
        {
            context = new OrgContext();
        }

        public List<ProxyEmployee> Employees()
        {
            try
            {
                return ObjectConverter.ConvertToProxyEmployee(context.new_employeeSet.ToList(), context);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public ProxyEmployee GetOneEmployee(Guid id)
        {
            ProxyEmployee covenant = null;
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var c = this.context.new_employeeSet.Where(i => i.Id == id).FirstOrDefault();
            if (c != null)
            {
                covenant = ObjectConverter.ConvertToOneProxyEmployee(c);
            }
            //}
            return covenant;
        }
    }
}
