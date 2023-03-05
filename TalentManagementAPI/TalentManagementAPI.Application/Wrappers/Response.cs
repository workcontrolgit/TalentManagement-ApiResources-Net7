using System.Collections.Generic;

namespace TalentManagementAPI.Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }



        /// <summary>
        /// Constructor for Response object.
        /// </summary>
        /// <param name="data">The data to be stored in the Response object.</param>
        /// <param name="message">Optional message to be stored in the Response object.</param>
        /// <returns>A Response object with the given data and message.</returns>
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }



        /// <summary>
        /// Constructor for Response class.
        /// </summary>
        /// <param name="message">The message to be set.</param>
        /// <returns>
        /// A Response object with Succeeded set to false and Message set to the given message.
        /// </returns>
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}