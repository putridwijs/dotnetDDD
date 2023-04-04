namespace billing_system_core.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password);