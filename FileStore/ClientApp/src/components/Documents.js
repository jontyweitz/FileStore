import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import { AddDocument } from './AddDocument'

export class Documents extends Component {

    constructor(props) {
        super(props);
        this.state = { documents: [], loading: true, showAddDocument: false };

        fetch('api/Document/ListDocuments')
            .then(response => response.json())
            .then(data => {                
                this.setState({ documents: data, loading: false });
            });
    }

    static renderDocumentsTable(documents) {
        if (documents.length === 0) {
            return (<p><em>No documents have been uploaded. Upload a document using the 'Add Document' button</em></p>)
        }
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Category</th>
                        <th>Last Reviewed</th>
                    </tr>
                </thead>
                <tbody>
                    {documents.map(document =>
                        <tr key={document.id}>
                            <td><a href={"api/document/" + document.id}>{document.fileName}</a></td>
                            <td>{document.category}</td>
                            <td>{document.lastReviewed}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Documents.renderDocumentsTable(this.state.documents);

        return (
            <div>
                <h1>Documents</h1>
                <Button onClick={() => this.setState({ showAddDocument: true })}>Add Document</Button>
                <div>
                    {contents}
                </div>
                <AddDocument show={this.state.showAddDocument} handleClose={() => this.setState({ showAddDocument: false })}></AddDocument>
            </div>
        );
    }
}
