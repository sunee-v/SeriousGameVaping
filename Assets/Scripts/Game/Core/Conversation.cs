using System;

[Serializable]
public struct Conversation
{
	public Dialogue[] Dialogues;
}
[Serializable]
public struct Dialogue
{
	public string Text;
	public float Duration;
}
