﻿using Application.Abstractions;
using MediatR;
using MapsterMapper;
using Application.Library.Dto;
using Application.Models;

namespace Application.Library.Queries
{
    public class GetUsersWithMostRentsQuery : IRequest<GetUsersWithMostRentsResponse>
    {
        public GetUsersWithMostRentsQuery(int topRange, DateTimeOffset startDate, DateTimeOffset returnDate)
        {
            TopRange = topRange;
            StartDate = startDate;
            ReturnDate = returnDate;
        }

        public int TopRange { get; private set; }

        public DateTimeOffset StartDate { get; private set; }

        public DateTimeOffset ReturnDate { get; private set; }

        public class GetUsersWithMostRentsQueryHandler : IRequestHandler<GetUsersWithMostRentsQuery, GetUsersWithMostRentsResponse>
        {
            private readonly ILibraryRepository libraryRepository;
            private readonly IMapper mapper;

            public GetUsersWithMostRentsQueryHandler(ILibraryRepository libraryRepository, IMapper mapper)
            {
                this.libraryRepository = libraryRepository;
                this.mapper = mapper;
            }

            public Task<GetUsersWithMostRentsResponse> Handle(GetUsersWithMostRentsQuery request, CancellationToken cancellationToken)
            {
                var response = new GetUsersWithMostRentsResponse
                {
                    Users = mapper.Map<List<UserMostRents>>(libraryRepository.GetUsersWithMostRents(request.TopRange, request.StartDate, request.ReturnDate))
                };

                return Task.FromResult(response);
            }
        }
    }
}
