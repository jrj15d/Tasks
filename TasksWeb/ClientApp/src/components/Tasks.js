import React, { Component } from 'react';

export class Tasks extends Component {
    static displayName = Tasks.name;

    constructor(props) {
        super(props);
        this.state = { tasks: [], loading: true };
    }

    componentDidMount() {
        this.populateTasksData();
    }

    static renderTasksTable(tasks) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Description</th>
                        <th>Completed</th>
                    </tr>
                </thead>
                <tbody>
                    {tasks.map(task =>
                        <tr key={task.id}>
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

        return (
            <div>
                <h1 id="tabelLabel" >Tasks</h1>
                {contents}
            </div>
        );
    }

    async populateTasksData() {
        const response = await fetch('tasks');
        const data = await response.json();
        this.setState({ tasks: data, loading: false });
    }
}
