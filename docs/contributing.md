# Contributing to Astral Drift
Any team members contributing to the project, take heed of the following GIT workflow practices:

(NOTE! for the next project team: I've deleted the existing branch protection rules for the Release and Development branch. Before starting off, you'll need to determine how you wish to protect your branches.)

If it's not already obvious: make sure everyone in the team is using the **same** GIT program.

## Development

### Branches
Currently, there are 3 main branches:

- main: used for updating documentation such as the readme and contributing.md
- Release: hosts the current release of the game. 
- Develop: the working branch for the development team.

### Start working on a feature/bug
When developing on a feature, bug, etc. One should create a feature branch off of the Development Branch.
When naming the branch, the convention for naming branches is **everything lowercase**, but camelCasing is allowed.

An example of a correct branc name looks like this: feature/theFeature

### Merging back to Development
When the feature/bug is finished, notify your team members so that they can Peer review your work.
This is done by creating a Pull request to the branch Develop so that another team member can do the Peer review.
As soon as your work is reviewed, the **reviewer** will merge your work back to Development.

#### Pull requests: How to create them
Creating a Pull request goes as follows:
1. Open Github.com and navigate to 'Pull requests'
2. Click on 'New Pull request'
3. Below 'Compare changes' you can see two branch names with dropdown menu's. The left branch is the branch you wish to merge _into_, the right branch is the branch you wish to merge _from_.
4. Click on 'Create Pull request'
5. Now you can provide extra information and commentary about your Pull request in the input field.
6. Next, assign a reviewer at 'reviewers' for your Pull request by clicking on the cog icon.
7. You can leave Assignees empty, but you usually assign yourself in a Pull request.
8. When you're ready, click on either 'Create pull request' OR click on the arrow next to the button to create a Draft pull request. With a draft you can revisit the request later, before submitting it.

#### Pull requests: How to review them
Reviewing a Pull request goes as follows:
1. Open Github.com and navigate to 'Pull requests'
2. Open the Pull request that you need to review.
3. Click on the 'Files changed' tab and review the changed files. You can change the format of the diff view in this tab by clicking and choosing the unified or split view. The choice you make will apply when you view the diff for other pull requests. 
4. Hover over the line of code where you'd like to add a comment, and click on the blue comment icon. To add a comment on multiple lines, click and drag to select the range of lines, then click the blue comment icon. 
5. When typing a comment, you can (optionally) suggest a specific change to the line(s) by typing the code in a code block like this:

```suggestion
  else if lineRange.length > 1
```

7. You can mark the file as 'Viewed' once you've viewed the file.
8. When you're done, click 'Start a review'. If you have already started a review, you can click 'Add review comment'.
9. Before you submit your review, your line comments are pending and only visible to you. You can edit pending comments anytime before you submit your review. To cancel a pending review, including all of its pending comments, scroll down to the end of the timeline on the Conversation tab, then click Cancel review.
10. Now to submit the review! On the Pull request, above the changed code in 'Files changed', click 'Review changes'.
11. Type a comment summarizing your feedback on the proposed changes. 
12. Select the type of review you'd like to leave: Comment, Approve, or Request changes.
13. Click 'Submit review'.
14. You're done reviewing! If you've left an Approve review, you can now start completing the Pull request. This is done by clicking 'Merge pull request'.

For more information on Pull requests, see one of these pages:
- [Creating a pull request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request)
- [Requesting a pull request review](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/requesting-a-pull-request-review)
- [Reviewing proposed changes in a pull request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/reviewing-changes-in-pull-requests/reviewing-proposed-changes-in-a-pull-request)
- [About pull request reviews](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/reviewing-changes-in-pull-requests/about-pull-request-reviews)

## Releasing
When a sufficient amount of features or bugfixes have been tested and are ready to be released, a Pull request is created to merge back to Release.
Two team members will review all of the work that is being merged back to Release using a **Squash Merge**.
Then, the work can be merged. After merging, the reviewers should test the release product and fix any after-merge errors.
