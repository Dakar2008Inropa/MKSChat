namespace App.WindowsService;

public sealed class WindowsBackgroundService : BackgroundService
{
  private readonly ChatService _chatService;
  public WindowsBackgroundService(ChatService chatService) => _chatService = chatService;

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await _chatService.ExecuteAsync();
    Environment.Exit(1);
  }
}