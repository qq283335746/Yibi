﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.NoSqlCore.Tables
{
    public class Students
    {
        public Students()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Sno { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
