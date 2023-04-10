using EmployeeManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.HttpMessageHandlers
{
    public class TestablePromotionEligibilityHandler : HttpMessageHandler
    {
        private readonly bool _isEligibleforPormotion; 
        public TestablePromotionEligibilityHandler(bool isEligibleforPormotion )
        {
            _isEligibleforPormotion = isEligibleforPormotion;
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            PromotionEligibility promotion = new PromotionEligibility()
            {
                EligibleForPromotion = _isEligibleforPormotion
            };
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(promotion, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }),
                Encoding.ASCII, "application/json")
            };
            return Task.FromResult(response);
        }
    }
}
