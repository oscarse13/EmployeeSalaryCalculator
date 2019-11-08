import React, { Component } from 'react';

export class EmployeeSalaryCalculator extends Component {
    static displayName = EmployeeSalaryCalculator.name;


    constructor(props) {
        super(props);
        this.state = { employees: [], loading: true, id: '', notFound: true, enableErrorMessage: false   };
        this.search = this.search.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.url = "https://localhost:44354/api/Employee/";
    }

    componentDidMount() {
        this.populateData();
    }

    search() {
        this.populateData(this.state.id);
    }

    handleChange(event) {
        this.setState({ id: event.target.value.replace(/\D/, '') });
    }

    static renderTable(employees) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Contract Type</th>
                        <th>Hourly Salary</th>
                        <th>Monthly Salary</th>
                        <th>Annual Salary</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map(employee =>
                        <tr key={employee.id}>
                            <td>{employee.id}</td>
                            <td>{employee.name}</td>
                            <td>{employee.contractTypeName}</td>
                            <td>{employee.hourlySalary}</td>
                            <td>{employee.monthlySalary}</td>
                            <td>{employee.annualSalary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.enableErrorMessage
            ? <p><em>Something went wrong...</em></p>
            : this.state.notFound
            ? <p><em>No records...</em></p>
            : this.state.loading
            ? <p><em>Loading...</em></p>
            : EmployeeSalaryCalculator.renderTable(this.state.employees);

        return (
            <div>
                <h1 id="tabelLabel" >Employees</h1>
                <p></p>
                <div className="row">
                    <div className="col-2"> 
                        <input type="text" value={this.state.id} onChange={this.handleChange} placeholder="Search by Id" />
                    </div>
                    <div className="col-10"> 
                        <button className="btn btn-primary" onClick={this.search}>Search</button>
                    </div>
                </div>
                {contents}
            </div>
        );
    }

    async populateData(id) {
        await id ? this.getEmployee(id) : this.getEmployees();
    }

    async getEmployee(id) {
        let employees = [];
        fetch(this.url + id)
            .then(this.fetchStatusHandler)
            .then(data => {
                if (data && data.id)
                    employees.push(data);

                this.setState({ employees: employees, loading: false, notFound: employees.length === 0, enableErrorMessage: data === null });
            })
            .catch(error => {
                this.handleError(error);
            });
    }

    async getEmployees() {
        fetch(this.url)
            .then(this.fetchStatusHandler)
            .then(data => {
                this.setState({ employees: data ? data : [], loading: false, notFound: data ? data.length === 0 : true, enableErrorMessage: data === null  });
            })
            .catch(error => {
                this.handleError(error);
            });
    }

    fetchStatusHandler(response) {
        if (response.status === 200) {
            return response.json();
        } else if (response.status === 404) {
            return [];
        }
        else {
            console.log(response);
            return null;
        }
    }

    handleError(error) {
        this.setState({ enableErrorMessage: true });
        console.log(error);
    }
}
