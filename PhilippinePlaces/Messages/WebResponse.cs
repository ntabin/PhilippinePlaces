namespace PhilippinePlaces.Messages
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class WebResponse<T> : WebResponse
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class WebResponse
    {
        private string message;

        public WebResponse()
        {
            this.Errors = new List<string>();
        }

        [JsonProperty("errors")]
        public ICollection<string> Errors { get; set; }

        [JsonProperty("message")]
        public string Message
        {
            get
            {
                return this.message ?? string.Join(string.Empty, this.Errors);
            }

            set
            {
                this.message = value;
            }
        }
    }
}
