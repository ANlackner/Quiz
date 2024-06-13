using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Gui.Models;

public class QuestionProviderItem
{
    public string Topic { get; private set; }

    IQuestionProvider _questionProvider;

    public IQuestionProvider QuestionProvider
    {
        get
        {
            return _questionProvider;
        }
    }

    ImageSource _imageSource;

    public ImageSource ImageSource
    {
        get
        {
            return _imageSource;
        }
    }

    public QuestionProviderItem(IQuestionProvider provider)
    {

        _questionProvider = provider;

        // convert base64 to image
        var imageBytes = Convert.FromBase64String(provider.Base64EncodedImage);
        MemoryStream imageDecodeStream = new(imageBytes);
        _imageSource = ImageSource.FromStream(() => imageDecodeStream);

        this.Topic = provider.Topic;
    }
}
