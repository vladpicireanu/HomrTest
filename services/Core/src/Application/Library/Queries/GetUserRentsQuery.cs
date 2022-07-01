﻿using Application.Abstractions;
using MediatR;
using MapsterMapper;
using Application.Library.Dto;
using Application.Models;

namespace Application.Library.Queries
{
    public class GetUserRentsQuery : IRequest<GetUserRentsResponse>
    {
        public GetUserRentsQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }

        public class GetUserRentsQueryHandler : IRequestHandler<GetUserRentsQuery, GetUserRentsResponse>
        {
            private readonly ILibraryRepository libraryRepository;
            private readonly IMapper mapper;

            public GetUserRentsQueryHandler(ILibraryRepository libraryRepository, IMapper mapper)
            {
                this.libraryRepository = libraryRepository;
                this.mapper = mapper;
            }

            public Task<GetUserRentsResponse> Handle(GetUserRentsQuery request, CancellationToken cancellationToken)
            {
                var response = new GetUserRentsResponse
                {
                    UserRents = mapper.Map<List<UserRent>>(libraryRepository.GetUserRents(request.UserId))
                };

                return Task.FromResult(response);
            }
        }
    }
}
