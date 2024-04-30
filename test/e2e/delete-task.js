import { Selector } from 'testcafe';

fixture `Delete Task`
    .page `http://167.86.105.61:5001/todolist`
    .pageLoadTimeout(5000)
    .retryTestPages(true);

test('Delete Task', async t => {
    const taskSelector = Selector(".task").withText("Test Task");

    // Wait for the task element to appear in the DOM
    await t.waitForSelector(taskSelector, { timeout: 5000 });

    // Click the delete-task-button button
    await t.click(taskSelector.find(".task-button"));

    // Assert that the task was deleted from the list by checking through task class values
    await t.expect(taskSelector.exists).notOk();
});