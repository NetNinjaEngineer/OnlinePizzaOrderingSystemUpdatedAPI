﻿using OnlinePizzaOrderingSystemUpdatedAPI.Enums;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Position Position { get; set; }
        public int? LocationId { get; set; } = null!;
    }
}
