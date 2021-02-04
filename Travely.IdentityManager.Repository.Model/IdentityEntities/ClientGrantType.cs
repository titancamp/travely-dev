﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public class ClientGrantType
    {
        public int Id { get; set; }
        public string GrantType { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
