using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.API.Requests;
public record NewGameWithPlayerIdsRequest(List<PlayerId> PlayerIds);