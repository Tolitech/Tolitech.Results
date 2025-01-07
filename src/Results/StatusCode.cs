namespace Tolitech.Results;

/// <summary>
/// Enumeration representing HTTP status codes.
/// </summary>
public enum StatusCode
{
    /// <summary>
    /// Indicates a successful response (200 OK).
    /// </summary>
    OK = 200,

    /// <summary>
    /// Indicates a successful creation response (201 Created).
    /// </summary>
    Created = 201,

    /// <summary>
    /// Indicates that the request has been accepted for processing, but the processing has not been completed (202 Accepted).
    /// </summary>
    Accepted = 202,

    /// <summary>
    /// Indicates a successful response with no content (204 No Content).
    /// </summary>
    NoContent = 204,

    /// <summary>
    /// Indicates that the requested resource resides temporarily under a different URI (302 Found).
    /// </summary>
    Found = 302,

    /// <summary>
    /// Indicates that the resource has not been modified since the last request (304 Not Modified).
    /// </summary>
    NotModified = 304,

    /// <summary>
    /// Indicates a bad request response (400 Bad Request).
    /// </summary>
    BadRequest = 400,

    /// <summary>
    /// Indicates an unauthorized response (401 Unauthorized).
    /// </summary>
    Unauthorized = 401,

    /// <summary>
    /// Indicates a forbidden response (403 Forbidden).
    /// </summary>
    Forbidden = 403,

    /// <summary>
    /// Indicates a not found response (404 Not Found).
    /// </summary>
    NotFound = 404,

    /// <summary>
    /// Indicates that the method specified in the request is not allowed for the resource (405 Method Not Allowed).
    /// </summary>
    MethodNotAllowed = 405,

    /// <summary>
    /// Indicates that the server timed out waiting for the request (408 Request Timeout).
    /// </summary>
    RequestTimeout = 408,

    /// <summary>
    /// Indicates a conflict response (409 Conflict).
    /// </summary>
    Conflict = 409,

    /// <summary>
    /// Indicates that the user has sent too many requests in a given amount of time (429 Too Many Requests).
    /// </summary>
    TooManyRequests = 429,

    /// <summary>
    /// Indicates an internal server error response (500 Internal Server Error).
    /// </summary>
    InternalServerError = 500,

    /// <summary>
    /// Indicates that the server received an invalid response from an upstream server (502 Bad Gateway).
    /// </summary>
    BadGateway = 502,

    /// <summary>
    /// Indicates that the server is temporarily unable to handle the request due to overload or server maintenance (503 Service Unavailable).
    /// </summary>
    ServiceUnavailable = 503,

    /// <summary>
    /// Indicates that the server, while acting as a gateway, did not receive a timely response from the upstream server (504 Gateway Timeout).
    /// </summary>
    GatewayTimeout = 504,
}