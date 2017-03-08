﻿using System;
using System.Collections.Generic;
using MediatR;
using OP.RememberTheDate.WebService.Models;

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByRangeQuery : IRequest<IEnumerable<DateModel>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}