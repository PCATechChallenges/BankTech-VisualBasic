Imports HtmlAgilityPack
Imports System.IO

Module Module1

    ' ## Extra challenges ##
    ' 1. What would you do to enable this to output wordcounts by each set of links followed?
    ' 2. The word count currently takes ALL text from an html file. What would you do to to only focus on the visible on-page text?
    ' 3. The URL handling currently needs full http:// addresses to follow links. How could you do this differently to make it more robust?

    ' DISCLAIMER: Remember, not all sites like to be scraped by robots. In some places it's probably even illegal. 
    ' ALWAYS MAKE SURE YOU HAVE THE SITE OWNER'S PERMISSION BEFORE GOING OUT AND SCRAPING STUFF!!

    Sub Main()
        Dim webUrlsDoc = "WebsiteURLs.txt"
        Dim wordsListDoc = "WordsList.txt"

        ' Load the contents of both files
        Dim webUrls = File.ReadLines(webUrlsDoc)
        Dim wordsList = File.ReadLines(wordsListDoc)

        ' Create the starting dictionary from the words list
        Dim wordCount = InitialiseWordDictionary(wordsList)

        For Each webUrl As String In webUrls

            Console.WriteLine("Starting word count for site: {0}", webUrl)

            ' Install the Html Agility Pack via NuGet for dealing with HTML (see the using statements aove)
            ' Don't forget to install XPath for silverlight 4 (available via NuGet) as well!
            Dim handler = New HtmlWeb()

            ' Load up the current URL
            Dim doc = handler.Load(webUrl)

            ' Grab the first X links on the first page
            Dim firstPageLinks = GetOnPageUrls(doc, 5)

            ' Parse the content of the first page into the word dictionary
            ScrapeWords(doc, wordCount)

            ' Then follow the set of links from the first page and parse their contents
            For Each link As String In firstPageLinks
                Dim subHandler = New HtmlWeb()
                Dim nextDoc = subHandler.Load(link)
                ScrapeWords(nextDoc, wordCount)
            Next

            ' Output the results!
            For Each word As KeyValuePair(Of String, Integer) In wordCount
                Console.WriteLine("{0} appears {1} times", word.Key, word.Value)
            Next

            ' Can you guess what is missing? 
            ' Hint: Are we looking at word counts for individual websites, or all of them being passed?

        Next

        Console.ReadLine()

    End Sub



    ''' <summary>
    ''' Takes an HTML document, splits out the on page words and increments the dictionary counter for matching words.
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="wordCount"></param>
    ''' <remarks></remarks>
    Sub ScrapeWords(ByVal doc As HtmlDocument, ByRef wordCount As Dictionary(Of String, Integer))

        ' Grab ALL of the text on the page
        Dim onPageText = doc.DocumentNode.InnerText

        ' Split out all words into an array of words and then cycle through it
        For Each word As String In onPageText.Split(" ")

            ' Ignore any words that don't appear in our dictionary
            If Not wordCount.ContainsKey(word) Then Continue For

            ' If we get this far, we can find the word  in the dictionary and increase it's value by 1
            wordCount(word) += 1

        Next

    End Sub


    ''' <summary>
    ''' Parse an HTML document for all links and return the href destinations.
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <param name="numberOfLinks"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetOnPageUrls(ByVal doc As HtmlDocument, ByVal numberOfLinks As Integer) As IEnumerable(Of String)

        Dim counter = 0
        Dim linksList = New List(Of String)

        ' Use XPath strings to search for <a> tags and their inner href attributes 
        ' (i.e. <a href="/somelink.html">click</a> )
        ' See http://www.w3schools.com/xpath/xpath_syntax.asp for XPath syntax
        For Each link As HtmlNode In doc.DocumentNode.SelectNodes("//a")

            ' Grab the internal link values of the <a> tags
            Dim linkValue = link.GetAttributeValue("href", "")

            ' Ignore any blank, index links or any missing Http links
            If (linkValue = "" Or linkValue.Contains("index") Or Not linkValue.Contains("http://")) Then Continue For

            ' If we get this far, we've got a valid link we can follow
            linksList.Add(linkValue)
            counter += 1

            If counter >= numberOfLinks Then Exit For
        Next

        Return linksList
    End Function


    ''' <summary>
    ''' Populates a new dictionary from a list of words and sets all their corresponding values to zero
    ''' </summary>
    ''' <param name="words"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function InitialiseWordDictionary(ByRef words As IEnumerable(Of String)) As Dictionary(Of String, Integer)

        Dim seedDictionary = New Dictionary(Of String, Integer)

        For Each word As String In words

            ' Trim the word of any whitespace and standardise it to lowercase
            Dim cleanWord = word.ToLower().Trim()

            ' We don't want any duplicate entries (we can't in a dictionary anyway) and then set any values to 0
            If Not (seedDictionary.ContainsKey(cleanWord)) Then seedDictionary.Add(cleanWord, 0)
        Next

        Return seedDictionary
    End Function



End Module
