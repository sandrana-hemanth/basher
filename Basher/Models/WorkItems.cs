﻿namespace Basher.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    public class WorkItems
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "value")]
        public WorkItem[] Items { get; set; }
    }

    public class WorkItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public Fields Fields { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

    public class UserStories
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "value")]
        public UserStory[] Items { get; set; }
    }

    public class UserStory : WorkItem
    {
        [JsonIgnore]
        public IList<WorkItem> Tasks { get; set; }
    }

    public class Fields
    {
        private const string None = "None";
        private string assignedTo;

        [JsonProperty(PropertyName = "System.Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "System.State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "System.AssignedTo")]
        public string AssignedToFullName
        {
            get => this.assignedTo ?? None;
            set
            {
                if (value != null && this.assignedTo != value)
                {
                    this.assignedTo = value;
                }
            }
        }

        [JsonIgnore]
        public string AssignedTo => this.AssignedToFullName?.Split(' ').FirstOrDefault() ?? None;

        [JsonProperty(PropertyName = "System.IterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty(PropertyName = "System.Reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ResolvedBy")]
        public string ResolvedByFullName { get; set; }

        [JsonIgnore]
        public string ResolvedBy => this.ResolvedByFullName?.Split(' ')?.FirstOrDefault() ?? None;

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ClosedBy")]
        public string ClosedByFullName { get; set; }

        [JsonIgnore]
        public string ClosedBy => this.ClosedByFullName?.Split(' ')?.FirstOrDefault() ?? None;

        [JsonProperty(PropertyName = "System.CreatedBy")]
        public string CreatedByFullName { get; set; }

        [JsonIgnore]
        public string CreatedBy => this.CreatedByFullName?.Split(' ')?.FirstOrDefault() ?? None;

        [JsonProperty(PropertyName = "System.ChangedBy")]
        public string ChangedByFullName { get; set; }

        [JsonIgnore]
        public string ChangedBy => this.ChangedByFullName?.Split(' ')?.FirstOrDefault() ?? None;

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Severity")]
        public string Severity { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Priority")]
        public int Priority { get; set; }

        [JsonIgnore]
        public int Criticality => App.Settings.CriticalityField.Equals(nameof(this.Severity), StringComparison.OrdinalIgnoreCase) ? int.Parse(this.Severity?.Split(' ').FirstOrDefault() ?? this.Priority.ToString()) : this.Priority;

        [JsonProperty(PropertyName = "System.CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.OriginalEstimate")]
        public float OriginalEstimate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.RemainingWork")]
        public float RemainingWork { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.CompletedWork")]
        public float CompletedWork { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.StoryPoints")]
        public float StoryPoints { get; set; }
    }


    public class VstsException
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "innerException")]
        public object InnerException { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "typeName")]
        public string TypeName { get; set; }

        [JsonProperty(PropertyName = "typeKey")]
        public string TypeKey { get; set; }

        [JsonProperty(PropertyName = "errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty(PropertyName = "eventId")]
        public int EventId { get; set; }
    }


    //public class BugFields
    //{
    //    [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Severity")]
    //    public string Severity { get; set; }

    //    [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Priority")]
    //    public int Priority { get; set; }

    //    [JsonIgnore]
    //    public int Criticality => App.Settings.CriticalityField.Equals(nameof(this.Severity), StringComparison.OrdinalIgnoreCase) ? int.Parse(this.Severity.Split(' ').FirstOrDefault()) : this.Priority;
    //}

    //public class UserStoryFields
    //{
    //    [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.StoryPoints")]
    //    public float StoryPoints { get; set; }
    //}

    //public class TaskFields
    //{
    //    [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.OriginalEstimate")]
    //    public float OriginalEstimate { get; set; }

    //    [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.RemainingWork")]
    //    public float RemainingWork { get; set; }

    //    [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.CompletedWork")]
    //    public float CompletedWork { get; set; }
    //}
}
