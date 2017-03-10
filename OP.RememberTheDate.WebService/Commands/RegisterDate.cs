using System;
using MediatR;

namespace OP.RememberTheDate.WebService.Commands
{
    public class RegisterDate : IRequest
    {
        public DateTime Date { get; set; }
        public string EventToMark { get; set; }
    }
}