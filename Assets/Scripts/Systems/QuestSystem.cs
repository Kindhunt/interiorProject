using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quest 
{
    private int _id;
    private string _description;
    private bool _completed;

    public int Id => _id;
    public string Description => _description;
    public bool Completed => _completed;
}

public class QuestSystem
{
	private readonly Dictionary<int, Quest> _quests = new Dictionary<int, Quest>();
	public void AddQuest(Quest quest) {
		_quests.Add(quest.Id, quest);
	}
	public void RemoveQuest(Quest quest) {
		_quests.Remove(quest.Id);
	}
	public Quest GetQuest(int id) {
		return _quests[id];
	}

}