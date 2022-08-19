﻿using MediatR;
using System;

namespace Ejournal.Application.Application.Command.User_s.UpdateUser
{
    public class UpdateAspNetUserCommannd : IRequest
    {
        public Guid UserId { get; set; }
        public bool Active { get; set; }
    }
}
