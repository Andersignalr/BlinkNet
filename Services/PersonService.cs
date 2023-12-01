
using BlinkNet.Data;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

public interface IPersonService
{
	Person GetPerson();
	void SetPerson(Person person);
	Task SetPersonFromLocalStorageAsync();
	Task GetPersonFromLocalStorageAsync();
	Task ClearPerson();
}

public class PersonService : IPersonService
{
	private Person _person;

	private readonly IJSRuntime _jsRuntime;

	public PersonService(IJSRuntime jsRuntime)
	{
		_jsRuntime = jsRuntime;
	}

	public Person GetPerson()
	{
		return _person;
	}

	public void SetPerson(Person person)
	{
		_person = person;
	}

	public async Task SetPersonFromLocalStorageAsync()
	{
		await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "person", JsonSerializer.Serialize(_person));
	}

	public async Task GetPersonFromLocalStorageAsync()
	{
		var storedPersonJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "person");
		if (!string.IsNullOrEmpty(storedPersonJson))
		{
			_person = JsonSerializer.Deserialize<Person>(storedPersonJson);
		}
	}

	public async Task ClearPerson()
	{
		// Remove a chave "person" do armazenamento local
		await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "person");
		_person = null; // Limpa o usuário na memória
	}
}
