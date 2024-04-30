import { Selector } from 'testcafe';

fixture `Mark Task`
    .page `http://167.86.105.61:5001/todolist`
    .pageLoadTimeout(5000)
    .retryTestPages(true);

test('Mark Task', async t => {
    const taskSelector = Selector(".task").withText("Test Task");

    // Wait for the task element to appear in the DOM
    await t.waitForSelector(taskSelector, { timeout: 5000 });

    // Find task-checkbox and click it
    await t.click(taskSelector.find(".task-checkbox"));

    // Assert that the task was marked by checking through task class values and checking for the checkbox being checked
    await t.expect(taskSelector.find(".task-checkbox").checked).ok();
});