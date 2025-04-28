using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public class WordFinder
    {
        private IEnumerable<string> _matrix = new List<string>();
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            try
            {
                //Logic
                //1° Create a list for vertical words
                //2° Merge wordStream with vertical words in VerticalandHorizontalStream list
                //3° Find the words  in VerticalandHorizontalStream
                //4° Return top 10 repeated words order by appeareance in a descending way

                List<string> vertical = new List<string>();
                List<FoundWord> found = new List<FoundWord>();
                //create a list that represents vertical columns
                foreach (var w in _matrix)
                {
                    int col = 0;
                    foreach (char letra in w.ToCharArray())
                    {
                        string currentword = vertical.Count > col ? vertical[col] : "";
                        string newWord = currentword + letra;
                        if (vertical.Count > col)
                        {
                            vertical[col] = newWord;
                        }
                        else
                        {
                            vertical.Add(newWord);
                        }

                        col++;
                    }
                }
                if (vertical[0].Length != _matrix.First().Length)
                {
                    throw new MatrixException("Matrix Error");
                }
                List<string> VerticalandHorizontalStream = _matrix.ToList();
                VerticalandHorizontalStream.AddRange(vertical);


                foreach (var word in wordStream.Distinct())
                {
                    int? count = VerticalandHorizontalStream.Where(l => l.Contains(word)).Count();

                    if (count != null && count > 0)
                    {
                        found.Add(new FoundWord() { Count = +count, Word = word });
                    }
                }

                var result = found.OrderByDescending(l => l.Count).Take(10).Select(l => l.Word);

                return result;
            }
            catch (MatrixException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
