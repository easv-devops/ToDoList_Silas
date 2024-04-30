import { Selector } from 'testcafe';

fixture `Mark Task`
    .page `http://167.86.105.61:5001/todolist`;

test('Mark Task', async t => {
    // Find task-checkbox and click it
    await t.click(Selector(".task").withText("Test Task").find(".task-checkbox"));
    
    // Assert that the task was marked by checking through task class values and checking for the checkbox being checked
    await t.expect(Selector(".task").withText("Test Task").find(".task-checkbox").checked).ok();
});