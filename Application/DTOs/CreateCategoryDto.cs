﻿namespace Application.DTOs
{
    public class CreateCategoryDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}


