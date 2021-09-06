using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:User,IEntity
    {
        public int UserId { get; set; }
        public int CompanyName { get; set; }

    }
}
