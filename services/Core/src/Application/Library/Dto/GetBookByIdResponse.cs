﻿namespace Application.Library.Dto
{
    public class GetBookByIdResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Pages { get; set; }

        public int Copies { get; set; }
    }
}
