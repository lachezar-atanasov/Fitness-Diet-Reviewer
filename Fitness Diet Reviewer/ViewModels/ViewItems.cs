namespace Fitness_Diet_Reviewer.ViewModels
{
    using Fitness_Diet_Reviewer.Models;
    using Microsoft.AspNetCore.Html;
    using System.Web;

    public static class ViewItems
    {
        public static HtmlString CreateSearchBox(string controller,string className, string dataUrl, string foodName = "Select a food", string productId="")
        {
            var defaultOption = foodName != "Select a food" ? $"<option value='{productId}' selected >{foodName}</option>":
                "<option value='' selected disabled>"+foodName+"</option>";
            var html = $@"
            <style>
                .select2-container {{
                    width: 500px;
                }}

                .select2-selection__arrow {{
                    height: 100%;
                }}

                .select2-selection__arrow b {{
                    border-color: #333 transparent transparent transparent;
                }}

                .select2-dropdown {{
                    border: 1px solid #ccc;
                    border-radius: 4px;
                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                }}

                .select2-results__option {{
                    padding: 8px;
                    color: #333;
                    background-color: #fff;
                    cursor: pointer;
                }}

                .select2-results__option--highlighted {{
                    background-color: #f0f0f0;
                }}

                .select2-selection__placeholder {{
                    color: #888;
                }}

                .select2-selection__rendered {{
                    color: #333;
                }}
            </style>
            <script>
                $(document).ready(function () {{
                    $('#{className}').select2({{
                        theme: 'bootstrap-5',
                        ajax: {{
                            url: '{dataUrl}',
                            dataType: 'json',
                            delay: 250,
                            data: function (params) {{
                                return {{
                                    term: params.term
                                }};
                            }},
                            processResults: function (data) {{
                                return {{
                                    results: data
                                }};
                            }},
                            cache: true
                        }},
                        minimumInputLength: 1,
                        tags: true, // Allow manual entry of text not in the dropdown
                    }});
                }});
            </script>

            <div class='col'>
                <select name='{controller}' id='{className}' class='form-select'>
                    {defaultOption}
                </select>
            </div>
        ";

            return new HtmlString(html);
        }

    }

}
