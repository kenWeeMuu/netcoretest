﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDb.Entitys
{
    public class MenuItem
    {
        public MenuItem() {
            Meta = new MenuMeta();
            Children = new List<MenuItem>();

        }

        public int MenuItemId { get; set; }

        public string Guid { get; set; }



        public string Name { get; set; }
        public string Path { get; set; }
        public string Component { get; set; }
        public int ParentId { get; set; }

        public MenuMeta Meta { get; set; }
        public List<MenuItem> Children { get; set; }
    }

    public class MenuMeta
    {
        public MenuMeta() {
            Permission = new List<string>();
            BeforeCloseFun = "";
        }

        public bool HideInMenu { get; set; }
        public string Icon { get; set; }
        public bool NotCache { get; set; }
        public string Title { get; set; }
        public List<string> Permission { get; set; }
        public string BeforeCloseFun { get; set; }
    }
}
