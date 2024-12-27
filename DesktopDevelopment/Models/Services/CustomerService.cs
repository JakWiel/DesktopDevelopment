using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;

namespace DesktopDevelopment.Models.Services
{
    public class CustomerService : BaseService<CustomerDto, Customer>
    {
        public override void AddModel(Customer model)
        {
            throw new NotImplementedException();
        }

        public override void DeleteModel(CustomerDto model)
        {
            throw new NotImplementedException();
        }

        public override Customer GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public override List<CustomerDto> GetModels()
        {
            throw new NotImplementedException();
        }

        public override void UpdateModel(Customer model)
        {
            throw new NotImplementedException();
        }
    }
}
