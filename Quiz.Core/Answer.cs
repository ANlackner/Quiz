using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core;

public class Answer : IAnswer
{
    public bool IsTrue { get; set; } = false;
    public string Text {  get; set; }

    public Answer(string text, bool istrue)
    {
        this.Text = text;
        this.IsTrue = istrue;
    }

    public Answer(string text) : this(text, false)
    {
        
    }
}
