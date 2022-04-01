using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MudBlazor;

namespace Website.Client.Components.DialogBuilder;

public class DialogBuilder
{
    public static DialogBuilder New(IDialogService DialogService, string Header) => new (DialogService, Header);
    
    public static async Task<string> GetString(IDialogService DialogService, string Header, string Message, string ExistingText = null)
    {
        var parameters = new DialogParameters
        {
            ["Text"] = ExistingText,
            ["Message"] = Message ?? "Name"
        };
        
        DialogOptions closeOnEscapeKey = new () { CloseOnEscapeKey = true };
        var dialog = DialogService.Show<StringEntryDialog>(Header, parameters, closeOnEscapeKey);

        var result = await dialog.Result;
        return (string)result.Data;
    }
    
    
    private readonly IDialogService _dialogService;
    private readonly string _header;
    
    private readonly Dictionary<string, DialogInput> Inputs = new ();

    public DialogBuilder(IDialogService DialogService, string Header)
    {
        _dialogService = DialogService;
        _header = Header;
    }

    public async Task<MultiDialogResult> Show()
    {
        var parameters = new DialogParameters { ["Entries"] = Inputs };
    
        DialogOptions closeOnEscapeKey = new () { CloseOnEscapeKey = true };
        var result = await _dialogService.Show<MultiInputDialog>(_header, parameters, closeOnEscapeKey).Result;
        
        return new MultiDialogResult((Dictionary<string, DialogInput>) result.Data);
    }
    
    public DialogBuilder WithString(string Name) { Inputs.Add(Name, new DialogInput(DialogInput.InputType.String, Name)); return this; }
    
    public DialogBuilder WithBoolean(string Name) { Inputs.Add(Name, new DialogInput(DialogInput.InputType.Boolean, Name)); return this; }
    
    public DialogBuilder WithEnum<TEnum>(string Name) where TEnum : struct, Enum { Inputs.Add(Name, new EnumDialogInput(typeof(TEnum), Name)); return this; }
    
    public DialogBuilder WithNumber(string Name) { Inputs.Add(Name, new DialogInput(DialogInput.InputType.String, Name)); return this; }
}


public struct MultiDialogResult
{
    public Dictionary<string, DialogInput> Results;

    public MultiDialogResult(Dictionary<string, DialogInput> results)
    {
        Results = results;
    }

    public string GetStringValue(string name)
    {
        var result = Results[name];
        return result.CurrentValue;
    }
    
    public int GetNumberValue(string name)
    {
        var result = Results[name];
        return int.Parse(result.CurrentValue);
    }
    
    public bool GetBooleanValue(string name)
    {
        var result = Results[name];
        return bool.Parse(result.CurrentValue);
    }
    
    public TEnum GetEnumValue<TEnum>(string name) where TEnum : struct, Enum
    {
        var result = Results[name];
        return Enum.Parse<TEnum>(result.CurrentValue);
    }
}
 

public class DialogInput
{
    public enum InputType
    {
        String,
        Boolean,
        Enum,
        Number
    }
    
    public InputType Type;
    public String Name; 
    public string CurrentValue; 
    
    public DialogInput(InputType type, string name, string ExistingValue = null)
    {
        Type = type;
        Name = name;
        CurrentValue = ExistingValue;
    } 
}
public class EnumDialogInput : DialogInput
{ 
    public string[] EnumValues; 

    public EnumDialogInput(Type TEnum, string name) : base(InputType.Enum, name)
    {
        EnumValues = Enum.GetNames(TEnum);
    } 
}