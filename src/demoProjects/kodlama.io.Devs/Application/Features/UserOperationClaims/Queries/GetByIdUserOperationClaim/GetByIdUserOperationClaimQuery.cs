﻿using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim
{
    public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { "Admin" };
        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, GetByIdUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<GetByIdUserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimShouldBeExistWhenRequested(request.Id);

                //Geliştirilebilir
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == request.Id);

                GetByIdUserOperationClaimDto getByIdUserOperationClaimDto = _mapper.Map<GetByIdUserOperationClaimDto>(userOperationClaim);

                return getByIdUserOperationClaimDto;
            }
        }
    }
}
