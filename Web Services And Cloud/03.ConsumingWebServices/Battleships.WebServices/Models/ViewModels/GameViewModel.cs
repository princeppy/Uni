using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleships.WebServices.Models.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }

        public string PlayerOne { get; set; }

        public string State { get; set; }

        public string PlayerOneName { get; set; }
    }
}