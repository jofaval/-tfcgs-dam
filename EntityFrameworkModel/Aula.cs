﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Aula
    {
        public override string ToString() => $"Piso: {Piso}, Num: {Num}";

        public string Codificate() => $"{Piso}{Num}";
    }
}
