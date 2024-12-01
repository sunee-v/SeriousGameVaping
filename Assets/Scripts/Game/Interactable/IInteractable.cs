public interface IInteractable
{
    float MaxRange { get; }
    void OnStartHover();
    void OnInteract();
    void OnEndHover();
    public abstract string GetInteractionText();
}
