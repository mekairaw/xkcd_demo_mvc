﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XKCDTest.DTO.ViewModels
{
    public class VMComic
    {
        public VMComicDetail Comic { get; set; }
        public int? PreviousComicId { get; set; }
        public int? NextComicId { get; set; }
        public int? FirstComicId { get; set; }
        public int? LastComicId { get; set; }
    }
}
