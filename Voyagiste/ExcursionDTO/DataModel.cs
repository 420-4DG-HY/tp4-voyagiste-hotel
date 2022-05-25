using CommonDataDTO;
    
    namespace ExcursionDTO
{

    public record Excursion(Guid ExcursionId, MeetingPoint MeetingPoint, ActivityType Activity);
    public record MeetingPoint(Guid MeetingPointId,  string Name, Address Address,string Description);
    public record ActivityType(Guid ActivityTypeId, string Name, string Description);
    // On publie autant de dispo qu'il y a de place, d'ou les ParticipantId
    // ExcursionAvailabilityId le ExcursionAvailabilityId devient invalide une fois la résa faite
    public record ExcursionAvailability(Guid ExcursionAvailabilityId, Guid ExcursionId, DateTime Start, int ParticipantId);
    public record ExcursionBooking(Guid ExcursionBookingId, Person Participant, Guid ExcursionId, DateTime Start, int ParticipantId, DateTime BookedWhen) :Booking(ExcursionBookingId,Participant,BookedWhen);
}