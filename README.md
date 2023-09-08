# Astral-Drift
Welcome to Astral Drift!

Astral Drift is about controlling a space ship shooting down enemies and avoiding their attack patterns.
![ad](https://github.com/Mathijs-Marks/Astral-Drift/assets/57790446/b37d3061-0ab2-4c1a-be47-508c9bbbf33e)
![AstralDriftQRFront](https://github.com/Mathijs-Marks/Astral-Drift/assets/57790446/d1e1b1cd-30a7-4f01-a7a4-3cf222a4c621)

## Contributing
Any team members contributing to the project, take heed of the following GIT workflow practices:

### Development
#### Start working on a feature/bug
When developing on a feature, bug, etc. One should create a branch off of the Development Branch.
This branch will have the name of the team member working in it.
If any wishes to keep features within their own branch, one can do so by branching off of their respective team member branch.
When giving that branch a name, prefix your branch name with either feature or bug, depending on what you're working on, followed with the name of your branch.
There the team member can work on the feature/bug until it is finished (don't forget to merge the finished feature back to the team member branch!).

#### Merging back to Development
When the feature/bug is finished, notify your team members so that they can Peer review your work.
This is done by creating a Pull request to the branch Develop so that another team member can do the Peer review.
As soon as your work is reviewed, the reviewer will merge your work back to Development.

##### Pull requests: How to create them
Creating a Pull request goes as follows:
1. Open Github.com and navigate to 'Pull requests'
2. Click on 'New Pull request'
3. Below 'Compare changes' you can see two branch names with dropdown menu's. The left branch is the branch you wish to merge _into_, the right branch is the branch you wish to merge _from_.
4. Click on 'Create Pull request'
5. Now you can provide extra information and commentary about your Pull request in the input field.
6. Next, assign a reviewer at 'reviewers' for your Pull request by clicking on the cog icon.
7. You can leave Assignees empty, but you usually assign yourself in a Pull request.
8. When you're ready, click on either 'Create pull request' OR click on the arrow next to the button to create a Draft pull request. With a draft you can revisit the request later, before submitting it.

##### Pull requests: How to review them
Reviewing a Pull request goes as follows:
1. Open Github.com and navigate to 'Pull requests'
2. Open the Pull request that you need to review.
3. Click on the 'Files changed' tab and review the changed files. You can change the format of the diff view in this tab by clicking and choosing the unified or split view. The choice you make will apply when you view the diff for other pull requests. 
4. Hover over the line of code where you'd like to add a comment, and click on the blue comment icon. To add a comment on multiple lines, click and drag to select the range of lines, then click the blue comment icon. 
5. When typing a comment, you can (optionally) suggest a specific change to the line(s) by typing the code like this:

```suggestion
  else if lineRange.length > 1
```
(Tip: at the readme, click on the hamburger menu and choose 'view raw' to actually see how to get this code block!)

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

### Releasing
When a sufficient amount of features or bugfixes have been tested and are ready to be released, a Pull request is created to merge back to Release.
Two team members will review all of the work that is being merged back to Release to ensure that any merge conflicts are fixed.
Then, the work can be merged. After merging, the reviewers should test the release product and fix any after-merge errors.
