﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlueDeck.Models.Types;

namespace BlueDeck.Models.ViewModels
{
    public class ComponentIndexListViewModel
    {        
        public IEnumerable<ComponentIndexViewModelComponentListItem> Components { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ComponentNameSort { get; set; }
        public string ParentComponentNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public ComponentIndexListViewModel(List<Component> components)
        {            
            Components = components.ConvertAll(x => new ComponentIndexViewModelComponentListItem(x));
        }
    }
}
