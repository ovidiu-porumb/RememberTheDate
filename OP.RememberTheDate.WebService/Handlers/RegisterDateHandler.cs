﻿using MediatR;
using OP.RememberTheDate.WebService.Commands;
using OP.RememberTheDate.WebService.Models;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class RegisterDateHandler : IRequestHandler<RegisterDate>
    {
        public void Handle(RegisterDate message)
        {
            //add here logic to persist the message
        }
    }
}