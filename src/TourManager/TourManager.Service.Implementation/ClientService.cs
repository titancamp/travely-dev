﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;
using TourManager.Repository.Entities;
using TourManager.Service.Abstraction;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation
{
    /// <summary>
    /// The bookings service interface
    /// </summary>
    public class ClientService : IClientService
    {
        /// <summary>
        /// The model mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The client repository
        /// </summary>
        private readonly IClientRepository clientRepository;

        /// <summary>
        ///  Create new instance of client service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="clientRepository">The client repository</param>
        public ClientService(IMapper mapper, IClientRepository clientRepository)
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
        }

        /// <summary>
        /// Get the clients of a tour
        /// </summary>
        /// <param name="tourId">The tour id</param>
        /// <returns></returns>
        public async Task<List<Client>> GetClients(int tourId)
        {
            var result = await this.clientRepository.GetAll(tourId);

            return this.mapper.Map<List<Client>>(result);
        }

        /// <summary>
        /// Get specific client by id 
        /// </summary>
        /// <param name="clientId">The client id</param>
        /// <returns></returns>
        public async Task<Client> GetClientById(int clientId)
        {
            var result = await this.clientRepository.GetById(clientId);

            return this.mapper.Map<Client>(result);
        }

        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client">The client to create</param>
        /// <returns></returns>
        public Task CreateClient(Client client)
        {
            return this.clientRepository.Add(this.mapper.Map<TourClientEntity>(client));
        }

        /// <summary>
        /// Update the specific client
        /// </summary>
        /// <param name="client">The client to update</param>
        /// <returns></returns>
        public Task UpdateClient(Client client)
        {
            return this.clientRepository.Update(this.mapper.Map<TourClientEntity>(client));
        }

        /// <summary>
        /// Remove specific client by id
        /// </summary>
        /// <param name="clientId">The client id to remove</param>
        /// <returns></returns>
        public async Task RemoveClient(int clientId)
        {
            var result = await this.clientRepository.GetById(clientId);

            await this.clientRepository.Remove(result);
        }
    }
}