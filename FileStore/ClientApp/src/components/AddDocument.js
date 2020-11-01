import React, { Component } from 'react';
import { Button, Modal, FormControl, Form, FormGroup, ControlLabel } from 'react-bootstrap';

export class AddDocument extends Component {

    constructor(props) {
        super(props);
    }

    render() {

        return (
            <Modal show={this.props.show} onHide={this.props.handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Add document</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <form action="api/document/upload" method="post" encType="multipart/form-data">
                        <FormGroup controlId="formControlsCategory">
                            <ControlLabel>Category</ControlLabel>
                            <FormControl
                                type="text"
                                placeholder="Category"
                                id="category"
                                required
                                name="category"
                            />
                            <ControlLabel>Last Reviewed</ControlLabel>
                            <FormControl
                                type="date"
                                id="lastReviewed"
                                required
                                name="lastReviewed"
                            />
                            <ControlLabel>File</ControlLabel>
                            <FormControl
                                type="file"
                                id="file"
                                required
                                name="file"
                            />
                        </FormGroup>
                        <Button variant="secondary" onClick={this.props.handleClose}>Close</Button>
                        <Button variant="primary" type="submit">Save Document</Button>
                    </form>
                </Modal.Body>
            </Modal>
        );
    }
}
