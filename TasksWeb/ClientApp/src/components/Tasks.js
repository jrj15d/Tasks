import { post } from 'jquery';
import React, { Component } from 'react';

export class Tasks extends Component {
    static displayName = Tasks.name;

    constructor(props) {
        super(props);
        this.state = { tasks: [], loading: true, dialog: false, title: "", description: "" };
        this.updateDialog = this.updateDialog.bind(this);
        this.updateTitle = this.updateTitle.bind(this);
        this.updateDescription = this.updateDescription.bind(this);
        this.addTask = this.addTask.bind(this);
    }

    componentDidMount() {
        this.populateTasksData();
    }

    updateDialog() {
        this.setState(prev => {
            return {
                dialog: !prev.dialog
            };
        });
    }

    updateTitle(event) {
        this.setState({
            title: event.target.value
        });
    }

    updateDescription(event) {
        this.setState({
            description: event.target.value
        });
    }

    addTask() {
        const task = {
            Id: 0,
            Title: this.state.title,
            Description: this.state.description,
            Completed: false
        };

        this.updateDialog();
        this.postTask(task);
    }

    static renderDialog(addTask, updateDialog, updateTitle, updateDesc) {
        return (
            <dialog open>
                <h1>New Task</h1>
                <div>
                    <h6>Title</h6>
                    <input type="text" onChange={updateTitle} />
                </div>
                <div>
                    <h6>Description</h6>
                    <input type="text" onChange={updateDesc} />
                </div>
                <div>
                    <button className="btn-primary" onClick={addTask}>Add</button>
                    <button className="btn-primary" onClick={updateDialog}>Close</button>
                </div>
            </dialog>
        );
    }

    static renderTasksTable(tasks) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Completed</th>
                    </tr>
                </thead>
                <tbody>
                    {tasks.map(task =>
                        <tr key={task.id}>
                            <td>{task.id}</td>
                            <td>{task.title}</td>
                            <td>{task.description}</td>
                            <td>{task.completed == true ? "Yes" : "No"}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Tasks.renderTasksTable(this.state.tasks);

        let dialog = this.state.dialog
            ? Tasks.renderDialog(this.addTask, this.updateDialog, this.updateTitle, this.updateDescription)
            : null;

        return (
            <div>
                <h1 id="tabelLabel" >My Tasks</h1>
                <button className="btn-primary" onClick={this.updateDialog}>Add</button>
                {dialog}
                {contents}
            </div>
        );
    }

    async postTask(task) {
        const request = {
            method: 'POST',
        };
        this.setState({ loading: true });
        const response = await fetch('tasks/' + JSON.stringify(task), request)
        const data = await response.json();
        this.setState(prev =>
        {
            return {
                tasks: prev.tasks.concat(data),
                loading: false
            }
        });
    }
    
    async populateTasksData() {
        const response = await fetch('tasks');
        const data = await response.json();
        this.setState({ tasks: data, loading: false });
    }
}
